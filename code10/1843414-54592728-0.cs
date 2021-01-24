         private void Abort(Exception exception, int abortState)
        {
            GlobalLog.ThreadContract(ThreadKinds.Unknown, "HttpWebRequest#" + ValidationHelper.HashString(this) + "::Abort()");
            if (Logging.On) Logging.Enter(Logging.Web, this, "Abort", (exception == null? "" :  exception.Message));
            if(Interlocked.CompareExchange(ref m_Aborted, abortState, 0) == 0) // public abort will never drain streams
            {
                GlobalLog.Print("HttpWebRequest#" + ValidationHelper.HashString(this) + "::Abort() - " + exception);
                NetworkingPerfCounters.Instance.Increment(NetworkingPerfCounterName.HttpWebRequestAborted);
                m_OnceFailed = true;
                CancelTimer();
                WebException webException = exception as WebException;
                if (exception == null)
                {
                    webException = new WebException(NetRes.GetWebStatusString("net_requestaborted", WebExceptionStatus.RequestCanceled), WebExceptionStatus.RequestCanceled);
                }
                else if (webException == null)
                {
                    webException = new WebException(NetRes.GetWebStatusString("net_requestaborted", WebExceptionStatus.RequestCanceled), exception, WebExceptionStatus.RequestCanceled, _HttpResponse);
                }
                try
                {
                        // Want to make sure that other threads see that we're aborted before they set an abort delegate, or that we see
                        // the delegate if they might have missed that we're aborted.
                        Thread.MemoryBarrier();
                        HttpAbortDelegate abortDelegate = _AbortDelegate;
                        if (abortDelegate == null || abortDelegate(this, webException))
                        {
                            // We don't have a connection associated with this request
                            SetResponse(webException);
                        }
                        else
                        {
                            // In case we don't call SetResponse(), make sure to complete the lazy async result
                            // objects. abortDelegate() may not end up in a code path that would complete these
                            // objects.
                            LazyAsyncResult writeAResult = null;
                            LazyAsyncResult readAResult = null;
                            if (!Async)
                            {
                                lock (this)
                                {
                                    writeAResult = _WriteAResult;
                                    readAResult = _ReadAResult;
                                }
                            }
                            if (writeAResult != null)
                                writeAResult.InvokeCallback(webException);
                            if (readAResult != null)
                                readAResult.InvokeCallback(webException);
                        }
                        if (!Async)
                        {
                            LazyAsyncResult chkConnectionAsyncResult = ConnectionAsyncResult;
                            LazyAsyncResult chkReaderAsyncResult = ConnectionReaderAsyncResult;
                            if (chkConnectionAsyncResult != null)
                                chkConnectionAsyncResult.InvokeCallback(webException);
                            if (chkReaderAsyncResult != null)
                                chkReaderAsyncResult.InvokeCallback(webException);
                        }
                        if (this.IsWebSocketRequest && this.ServicePoint != null)
                        {
                            this.ServicePoint.CloseConnectionGroup(this.ConnectionGroupName);
                        }
                }
                catch (InternalException)
                {
                }
            }
            if(Logging.On)Logging.Exit(Logging.Web, this, "Abort", "");
        }
