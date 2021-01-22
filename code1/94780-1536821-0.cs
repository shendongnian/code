private ToolStripMenuItem getToolStripMenuItemByName(string nameParam)
{
            foreach (Control ctn in this.Controls)
            {
                if (ctn is ToolStripMenuItem)
                {
                    if (ctn.Name = nameParam)
                    {
                        return ctn;
                    }
                }
            }
            return null;
        }
