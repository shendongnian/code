        protected void IdentityLabelInit(object sender, EventArgs e)
        {
            System.Threading.Thread testThread = new Thread(ReportIdentity);
            testThread.Start();
            testThread.Join();
        }
        private void ReportIdentity()
        {
            identityLabel.InnerText = "Initialized: " + System.Threading.Thread.CurrentPrincipal.Identity.Name;
            System.Security.Principal.IPrincipal currentPrincipal = System.Threading.Thread.CurrentPrincipal;
            SetAnonymousIdentity();
            System.Security.Principal.IPrincipal newPrincipal = System.Threading.Thread.CurrentPrincipal;
            if (newPrincipal.Equals(currentPrincipal))
                identityLabel.InnerText += ("no change");
            else
                identityLabel.InnerText += " | new name: " + System.Threading.Thread.CurrentPrincipal.Identity.Name;
        }
        private void SetAnonymousIdentity()
        {
            WindowsIdentity tIdentity = WindowsIdentity.GetAnonymous();
            WindowsPrincipal tPrincipal = new WindowsPrincipal(tIdentity);
            System.Threading.Thread.CurrentPrincipal = tPrincipal;
        }
