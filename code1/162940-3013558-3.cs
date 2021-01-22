    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;  // You need this namespace for ListBox
    
    namespace WindowsApplication1
    {
    
        public class CustomListBox : ListBox
        {
    
            public CustomListBox()
                : base()
            {
            }
    
            public bool SortByJG;
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
                            bool swap = false;
                            if (this.SortByJG)
                            {
                                string[] breakDownCurrent = this.Items[counter].ToString().Split(' ');
                                string[] breakDownPrevious = this.Items[counter - 1].ToString().Split(' ');
                                if (breakDownCurrent[1].CompareTo(breakDownPrevious[1]) == -1)
                                {
                                    swap = true;
                                }
                            }
                            else
                            {
                                if (this.Items[counter].ToString().CompareTo(
                                    this.Items[counter - 1].ToString()) == -1)
                                {
                                    swap = true;
                                }
                            }
    
                            if (swap)
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
    }
