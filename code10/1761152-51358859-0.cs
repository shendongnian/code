             listview.ItemAppearing += listviewItemAppearing;
             listview.ItemDisappearing += listviewItemDisappearing;
    
             bool m_scrolledToEnd;
    
            private void listviewItemDisappearing(object sender, ItemVisibilityEventArgs e)
            {
                if(e.Item == yourlastiem) 
                  m_scrolledToEnd = false;
            }
    
            private void listviewItemAppearing(object sender, ItemVisibilityEventArgs e)
            {
                if(e.Item == yourlastiem) 
                  m_scrolledToEnd = true;
            }
