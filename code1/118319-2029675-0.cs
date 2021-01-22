    Consider making an IThing interface.  Then every IThing implementation would be entirely dependant on the class that returns it, so then you can declare the structure or class implementing IThing inside the class implementing IWidget like this:
        interface IWidget
        {
            IList<IThing> LookupThings()
            {
                …
            }
        }
        interface IThing
        {
            …
        }
        class MyWidget : IWidget
        {
            IList<IThing> IWidget.LookupThings()
            {
                 …
            }
            private class MyWidgetThings : IThing
            {
                 …
            }
        }
