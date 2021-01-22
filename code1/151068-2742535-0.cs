    public class MyListBox: ListBox{
    
        public MyListBox()
        { 
             this.SelectionChanged += (s,e)=>{ RefreshBindings(); };
        }
    
        private void RefreshBindings()
        {
             BindingExpression be = 
                 (BindingExpression) GetBindingExpression(
                                          SelectedItemsProperty);
             if(be!=null){
                   bd.UpdateTarget();
             }
        }
    
    }
