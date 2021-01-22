    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;  // You need this namespace for ListBox
    public class CustomListBox : ListBox
    {
        public CustomListBox()
            : base()
        {
        }
        protected override void Sort()
        {
            if (this.Items.Count > 1)
            {
                bool swapped;
                do
                {
                    
                    int counter = this.Items.Count - 1;
                    swapped = false;
                    while (counter > 0)
                    {
                        if (this.Items[counter].ToString().CompareTo(
                            this.Items[counter - 1].ToString()) == -1)
                        {
                            object temp = Items[counter];
                            this.Items[counter] = this.Items[counter - 1];
                            this.Items[counter - 1] = temp;
                            swapped = true;
                        }
                        counter -= 1;
                    }
                }
                while (swapped);
            }
        }
    }
