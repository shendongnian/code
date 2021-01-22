    if(!IsPostBack) {
           InitializeCurrentLoadCB();
           InitializeSystemTypeCB();
    
           //Cable size filter
           if ((cb_test_1.SelectedIndex==0)||
                  (cb_test_1.SelectedIndex==1)||
                  (cb_test_1.SelectedIndex==2)||
                  (cb_test_1.SelectedIndex==3))
           {
                  InitializeCableSizeCB0();
                  InitializeCableLookup0();
           }
    }
