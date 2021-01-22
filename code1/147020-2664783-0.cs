        protected void lvwComments_OnItemCreated(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem currentItem = (e.Item as ListViewDataItem);
            Comment comment = (Comment)currentItem.DataItem;
            if (comment == null)
                return;
            string controlPath = string.Empty;
            switch (comment.Type)
            {
                case CommentType.User:
                    controlPath = "~/layouts/controls/General Comment.ascx";
                    break;
                case CommentType.Official:
                    controlPath = "~/layouts/controls/Official Comment.ascx";
                    break;
            }
            ListViewTemplateControl<Comment> templateControl = LoadControl(controlPath) as ListViewTemplateControl<Comment>;
            if (templateControl != null)
            {
                templateControl.CurrentItem = comment;
                templateControl.ID = comment.ItemID;
                lvwComments.Controls.Add(templateControl);
            }
        }
