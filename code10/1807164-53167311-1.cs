     public class Accordion : ContentView
        	{
        		#region Private Variables
        		List<AccordionSource> mDataSource;
        		bool mFirstExpaned = false;
        
                #endregion
        
        
                //Add targetlayout and targetbtnlist to store the target information which your want to expand.
                public StackLayout mMainLayout;
                public StackLayout targetLayout;
        
                public List<AccordionButton> btnList;
                public List<AccordionButton> targetBtnList;
        
                public Accordion ()
        		{
        			var mMainLayout = new StackLayout ();
        			Content = mMainLayout;
        		}
        
        		public Accordion (List<AccordionSource> aSource)
        		{
        			mDataSource = aSource;
        			DataBind();
        		}
        
        		#region Properties
        		public List<AccordionSource> DataSource 
        		{   get{ return mDataSource; }
        			set{ mDataSource = value; }  }
        		public bool FirstExpaned 
        		{   get{ return mFirstExpaned; }
        			set{ mFirstExpaned = value; }  }
        		#endregion
        
        		public void DataBind()
        		{
        			var vMainLayout = new StackLayout ();
                    btnList = new List<AccordionButton> { };
        			var vFirst = true;
        			if (mDataSource != null) {
        				foreach (var vSingleItem in mDataSource) {
        
        					var vHeaderButton = new AccordionButton () { Text = vSingleItem.HeaderText, 
        						TextColor = vSingleItem.HeaderTextColor,
        						BackgroundColor = vSingleItem.HeaderBackGroundColor
        					};
        
        					var vAccordionContent = new ContentView () { 
        						Content = vSingleItem.ContentItems,
        						IsVisible = false
        					};
        					if (vFirst) {
        						vHeaderButton.Expand = mFirstExpaned;
        						vAccordionContent.IsVisible = mFirstExpaned;
        						vFirst = false;
        					} 
        					vHeaderButton.AssosiatedContent = vAccordionContent;
        					vHeaderButton.Clicked += OnAccordionButtonClicked;
        					vMainLayout.Children.Add (vHeaderButton);
        					vMainLayout.Children.Add (vAccordionContent);
        
        
                            //store your buttons to use in the expand function
                            btnList.Add(vHeaderButton);
                        }
                    }
        			mMainLayout = vMainLayout;
        			Content = mMainLayout;
        		}
        
        		void OnAccordionButtonClicked (object sender, EventArgs args)
        		{
        
                    //get the target layout  which you want to expand
                    StackLayout temp = targetLayout;
        
                    //get a vSenderButton for which vSenderButton's AssosiatedContent you want to expand
                    //here I take targetBtnList[1] as a example, you can sepcify whatever you want to expand
                    AccordionButton vSenderButton = targetBtnList[1];
        
                    foreach (var vChildItem in temp.Children) {
                        if (vChildItem.GetType() == typeof(ContentView)) vChildItem.IsVisible = false;
                        if (vChildItem.GetType () == typeof(AccordionButton)) {
        					var vButton = (AccordionButton)vChildItem;
        
                            if (vButton != vSenderButton)
                            {
                                vButton.Expand = false;
                            }
                        }
        			}
        
        
                    //var vSenderButton = (AccordionButton)sender;
                    if (vSenderButton.Expand)
                    {
                        vSenderButton.Expand = false;
                    }
                    else vSenderButton.Expand = true;
                    vSenderButton.AssosiatedContent.IsVisible = vSenderButton.Expand;
        
                    //replace the vSenderButton in the targetBtnList to update its Expand property
                    targetBtnList[1] = vSenderButton;
                }
