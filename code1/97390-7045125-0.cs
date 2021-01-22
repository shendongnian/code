        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !HandlingRightClick)
            {
                HandlingRightClick = true;
                if (!cmsRightClickMenu.Visible)
                    cmsRightClickMenu.Show(this, e.Location);
                else cmsRightClickMenu.Hide();
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            HandlingRightClick = false;
            base.OnMouseUp(e);
        }
        private bool HandlingRightClick { get; set; }
