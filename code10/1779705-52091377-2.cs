        private void ContextMenuStrip_MouseLeave(object sender, EventArgs e)
        {
            ContextMenuStrip cms = (sender is ContextMenuStrip) ? sender as ContextMenuStrip : null;
            //Recognize CMS or TSDDM, in this case we dont need anything else
            if (cms != null)
            {
                //Check, if mouse position is on any of CMS DropDownMenus. 
                //If false, close CMS. If true, we dont want to close it - CMS is actively in use
                if (!IsMouseOnDropDown(cms.Items)) { cms.Close(); }
            }
            else
            {
                ToolStripDropDownMenu ddm = (sender is ToolStripDropDownMenu) ? sender as ToolStripDropDownMenu : null;
                if (ddm != null)
                {
                    //As above, check mouse position against items DropDownMenus
                    if (IsMouseOnDropDown(ddm.Items)) { return; }
                    //Declare our CMS
                    cms = GetPrimaryOwner(ddm);
                    //Get TSDDM owner
                    //var is important here, because we dont know if it is CMS or another TSDDM!!!
                    //Also TSDDM and CMS have the same properties for our purpose, so var is OK
                    var owner = ddm.OwnerItem.Owner;
                    Point pnt = Cursor.Position;
                    //If owner doesn't contains mouse position, close whole CMS
                    if (!owner.Bounds.Contains(pnt))
                    {
                        cms.Close();
                    }
                    else
                    {
                        //If does, we need to check if mouse position is exactly on parent item, 
                        //because its prevent to TSDDM unnecessary close/open 
                        //(explanation: Mouse leave TSDDM -> TSDDM close; 
                                      //Mouse is on parent item -> TSDDM open)
                        for (int i = 0; i < owner.Items.Count; i++)
                        {
                            //Define own rectangle, because item has its own bounds against the owner
                            //so we need to add up their X and Y to get the real one
                            int x = owner.Bounds.X + (owner.Items[i] as ToolStripMenuItem).Bounds.X;
                            int y = owner.Bounds.Y + (owner.Items[i] as ToolStripMenuItem).Bounds.Y;
                            Rectangle rect = new Rectangle(new Point(x, y), (pupik.Items[i] as ToolStripMenuItem).Bounds.Size);
                            //If its our DropDownMenu and mouse position is in there,
                            //we dont want to close ddm
                            if ((owner.Items[i] as ToolStripMenuItem).DropDown == ddm
                                && rect.Contains(pnt))
                            {
                                return;
                            }
                        }
                        ddm.Close();
                    }
                }
            }
        }
