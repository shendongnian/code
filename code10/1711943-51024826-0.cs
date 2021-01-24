     var treeGridView = new TreeGridView
            {
                BackgroundColor = Colors.White
            };
            treeGridView.Columns.Add(new GridColumn
            {
                HeaderText = "Content Type",
                DataCell = new TextBoxCell(0)
            });
            treeGridView.Columns.Add(new GridColumn
            {
                HeaderText = "Create",
                DataCell = new CustomCell
                {
                    CreateCell = r =>
                    {
                        TreeGridItem item = r.Item as TreeGridItem;
                        ContentTypeTag tag = (ContentTypeTag)item.Tag;
                        var contentType = _siteManager.CurrentSite.ContentTypes.First(x => x.Name.Equals(tag.ClassName));
                        void Click(object btnSender, EventArgs btnArgs)
                        {
                            //Your Event
                        }
                        var button = new LinkButton
                        {
                            Style = "primary-link-btn",
                            Text = $"Create {contentType.Name.ToSentenceCase()}",
                            Command = new Command(Click)
                        };
                        return button;
                    }
                }
            });
            treeGridView.Columns.Add(new GridColumn
            {
                HeaderText = "Show All",
                DataCell = new CustomCell
                {
                    CreateCell = r =>
                    {
                        TreeGridItem item = r.Item as TreeGridItem;
                        ContentTypeTag tag = (ContentTypeTag)item.Tag;
                        var contentType = _siteManager.CurrentSite.ContentTypes.First(x => x.Name.Equals(tag.ClassName));
                        void Click(object btnSender, EventArgs btnArgs)
                        {
                           //Your Event
                        }
                        var button = new LinkButton
                        {
                            Style = "primary-link-btn",
                            Text = $"Show All {contentType.Name.ToSentenceCase()}",
                            Command = new Command(Click)
                        };
                        return button;
                    }
                }
            });
                var treeGridItemCollection = new TreeGridItemCollection();
                foreach (var contentType in _siteManager.CurrentSite.ContentTypes)
                {
                    var item = new TreeGridItem
                    {
                        Values = new string[] { contentType.Name.ToSentenceCase(), "Create", "Show All" },
                        Tag = new ContentTypeTag
                        {
                            ClassName = contentType.Name
                        }
                    };
                    treeGridItemCollection.Add(item);
                }
                treeGridView.DataStore = treeGridItemCollection;
