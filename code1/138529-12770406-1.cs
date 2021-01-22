    namespace YourApp
    {
    	public static class MyExtensions
    	{
    		// Based upon http://www.knowdotnet.com/articles/listviewmoveitem.html
    		public static void MoveSelectedItem(this System.Windows.Forms.ListView lv, int idx, bool moveUp)
    		{
    			// Gotta have >1 item in order to move
    			if(lv.Items.Count > 1)	
    			{
    				int offset = 0;
				if (idx >= 0)
				{
					if (moveUp)
					{
						// ignore moveup of row(0)
						offset = -1;
					}
					else
					{
						// ignore movedown of last item
						if (idx < (lv.Items.Count - 1))
							offset = 1;
					}
				}
    				if (offset != 0)
    				{
    					lv.BeginUpdate();
    
    					int selitem = idx + offset;
    					for (int i = 0; i < lv.Items[idx].SubItems.Count; i++)
    					{
    						string cache = lv.Items[selitem].SubItems[i].Text;
    						lv.Items[selitem].SubItems[i].Text = lv.Items[idx].SubItems[i].Text;
    						lv.Items[idx].SubItems[i].Text = cache;
    					}
    
    					lv.Focus();
    					lv.Items[selitem].Selected = true;
    					lv.EnsureVisible(selitem);
    
    					lv.EndUpdate();
    				}
    			}
    		}
      	  }
    }
