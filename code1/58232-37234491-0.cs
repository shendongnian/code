    string eventBuffer;
    void GetContracts_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                var web = sender as WebBrowser;
                if (web.Url == e.Url)
                {
                    TaskMaster.Get_Contracts(ref web);
                    if(Memory.Contracts.Count==0)
                    {
                        eventBuffer="UpdateContractFailed";
                        web.Disposed += new EventHandler(web_Disposed);
                        web.Dispose();
                        return;
                    }
                    eventBuffer="UpdateContractList";
                    web.Disposed += new EventHandler(web_Disposed);
                    web.Dispose();
                }
            }
    
    private void web_Disposed(object sender, EventArgs e)
            {
                FireEvent(eventBuffer);
                GC.Collect();
                thread.Abort();
            }
