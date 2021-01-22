            ArrayList alDiscoveredNodes = this.DiscoverNetworNodes();
            //initializeViewDataTable will add colums to ViewDataTable that will be shown on View
            initializeViewDataTable(alDiscoveredNodes);
            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (setPopulateTree)delegate(ArrayList alNodes)
            {
                this.PopulateTreeView(alNodes);
                //this.DrawChart(dtProtocolDetails);                
            }, alDiscoveredNodes);
            
			//GetNetworkComputers objGetNetworkComputers = new GetNetworkComputers(100);
            DataTable dtProtocolInfo = objCProtocols.ScanForProtocols(alDiscoveredNodes);
            
            //Calling populateViewDataTable will take dtProtocolInfo by reference and then it will create 
            // another datatable that is for viewsing purpose
            populateViewDataTable(ref dtProtocolInfo);
            
            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (setData)delegate(DataTable dtProtocolDetails)
            {
                dataGridRunningProtocols.DataContext = dtProtocolDetails;
                
            }, dtProtocolInfo);
            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (setChartData)delegate(ref DataTable dtProtocolDetails)
            {
                try
                {
                    DrawChart(dtProtocolDetails);                   
                    
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.InnerException.ToString());
                }
            }, dtProtocolInfo);
            Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (setChartTitle)delegate(string strTitle)
            {
                mainChart.Title = "Protocol Availability Over Network";
                
            }, "");
            //pThread.Abort();
           // splash.Close(new TimeSpan(00, 00, 3));
		}
        
        /// <summary>
        /// It will add Columns to DataTable at run time according to columns defined in
        /// ProtocolConfigration Array
        /// </summary>
        private void initializeViewDataTable(ArrayList alHosts)
        {
            DataColumn dt = null;
            viewDataTable = new DataTable();
            viewDataTable.Columns.Add("Host");
            for (int i = 0; i < ProtocolConfiguration.STR_ARR_PROTOCOLS.Length; i++)
            {
                //viewDataTable.Columns.Add(ProtocolConfiguration.STR_ARR_PROTOCOLS[i][1] + " (" + ProtocolConfiguration.STR_ARR_PROTOCOLS[i][0] + " )", System.Type.GetType("System.Boolean"));                
                dt = new DataColumn(ProtocolConfiguration.STR_ARR_PROTOCOLS[i][1] + " (" + ProtocolConfiguration.STR_ARR_PROTOCOLS[i][0] + " )");
                //dt.DataType = typeof(System.Windows.Controls.CheckBox);
                dt.DataType = typeof(bool);
                viewDataTable.Columns.Add(dt);                
            }
           foreach (string strHost in alHosts)
           {
             
               
               //CheckBox cbTemp = new CheckBox();
               //cbTemp.IsChecked = true;
               viewDataTable.Rows.Add(strHost, false);
           }
        }
