                for (int i = eventViewer.GetErrorEventsCount() - 1; i >= 0; i--)
            {
                bResult = eventViewer.SelectMainEventViaErrorEvent(i);
                if (!bResult)
                {
                    break;
                }
                System.Threading.Thread.Sleep(2000);
            }
