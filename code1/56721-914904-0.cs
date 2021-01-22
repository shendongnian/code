    using (new UseDialogOnce(ie.DialogWatcher, approveConfirmDialog))
            {
                ie.Button(Find.ByName("btn")).ClickNoWait();
                approveConfirmDialog.WaitUntilExists();
                approveConfirmDialog.OKButton.Click();
                ie.WaitForComplete();
            }
           
