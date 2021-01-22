    protected void Page_Load(object sender, EventArgs e)
    {
       ListBox1.SelectionMode = System.Web.UI.WebControls.ListSelectionMode.Multiple;    
       for (int i = 0; i < ListBox1.Items.Count; i++)    
       {
          // Select the first, third and fifth items in the listbox
          if(i == 0 || i == 2 || i == 4)        
          {
             ListBox1.Items[i].Selected = true; 
          }
       }
    }
