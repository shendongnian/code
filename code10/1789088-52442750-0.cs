        var myList = new List<*Event or something*>(); //your list here
        MyButtons.Children.Clear(); //just in case so you can call this code several times np..
                    foreach (var item in myList)
                    {
                        var btn = new Button()
                        {
                            Text = item.*your property*, //Whatever prop you wonna put as title;
                            StyleId = item.*your ID property* //use a property from event as id to be passed to handler
                        };
                        btn.Clicked += OnDynamicBtnClicked;
                        MyButtons.Children.Add(btn);
                    }
