                    MyButton groupMembers = new MyButton();
                //Change text to username
                groupMembers.Text = usersInGroup[i];
                groupMembers.HorizontalOptions = LayoutOptions.FillAndExpand;
                groupMembers.VerticalOptions = LayoutOptions.Center;
                groupMembers.TextColor = Color.Black;
                groupMembers.BackgroundColor = Color.White;
                groupMembers.Clicked += GroupMembers_Clicked;
                grdMembersGrid.Children.Add(groupMembers, 0, userRowIndex);
