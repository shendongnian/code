                var insertPos = 0;
                foreach ( ListViewItem s in sourceList.SelectedItems )
                {
                    s.Remove ( );
                    var copyCode = Int32.Parse ( s.Text );
                    while ( insertPos < destinationList.Items.Count )
                    {
                        var itemAtCandidate = Int32.Parse ( destinationList.Items [ insertPos ].Text );
                        if ( itemAtCandidate > copyCode )
                            break;
                        insertPos++;
                    }
                    destinationList.Items.Insert ( insertPos, s );
                }
