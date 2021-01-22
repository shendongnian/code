            private void Info_MouseHover(object sender, EventArgs e)
        {
            Control senderObject = sender as Control;
            string hoveredControl = senderObject.Tag.ToString();
            // only instantiate a tooltip if the control's tag contains data
            if (hoveredControl != "")
            {
                ToolTip info = new ToolTip
                {
                    AutomaticDelay = 500
                };
                string tooltipMessage = string.Empty;
                
                // add all conditionals here to modify message based on the tag of the hovered control
                if (hoveredControl == "save button")
                {
                    tooltipMessage = "This button will save stuff.";
                }
                info.SetToolTip(senderObject, tooltipMessage);
            }
        }
