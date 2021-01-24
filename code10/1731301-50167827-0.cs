     public class Resolution
        {
            float heightRatio = new float();
            float widthRatio = new float();
            int standardHeight, standardWidth;
            public void ResizeForm(Form objForm, int DesignerHeight, int DesignerWidth)
            {
                standardHeight = DesignerHeight;
                standardWidth = DesignerWidth;
                int presentHeight = Screen.PrimaryScreen.WorkingArea.Height;//.Bounds.Height;
                int presentWidth = Screen.PrimaryScreen.Bounds.Width;
                heightRatio = (float)((float)presentHeight / (float)standardHeight);
                widthRatio = (float)((float)presentWidth / (float)standardWidth);
                objForm.AutoScaleMode = AutoScaleMode.None;
                objForm.Scale(new SizeF(widthRatio, heightRatio));
                foreach (Control c in objForm.Controls)
                {
                    if (c.HasChildren)
                    {
                        ResizeControlStore(c);
                    }
                    else
                    {
                        c.Font = new Font(c.Font.FontFamily, c.Font.Size * heightRatio, c.Font.Style, c.Font.Unit, ((byte)(0)));
                    }
                }
                objForm.Font = new Font(objForm.Font.FontFamily, objForm.Font.Size * heightRatio, objForm.Font.Style, objForm.Font.Unit, ((byte)(0)));
            }
    
            private void ResizeControlStore(Control objCtl)
            {
                if (objCtl.HasChildren)
                {
                    foreach (Control cChildren in objCtl.Controls)
                    {
                        if (cChildren.HasChildren)
                        {
                            ResizeControlStore(cChildren);
    
                        }
                        else
                        {
                            cChildren.Font = new Font(cChildren.Font.FontFamily, cChildren.Font.Size * heightRatio, cChildren.Font.Style, cChildren.Font.Unit, ((byte)(0)));
                        }
                    }
                    objCtl.Font = new Font(objCtl.Font.FontFamily, objCtl.Font.Size * heightRatio, objCtl.Font.Style, objCtl.Font.Unit, ((byte)(0)));
                }
                else
                {
                    objCtl.Font = new Font(objCtl.Font.FontFamily, objCtl.Font.Size * heightRatio, objCtl.Font.Style, objCtl.Font.Unit, ((byte)(0)));
                }
            }
        }
