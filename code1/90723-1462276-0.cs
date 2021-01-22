    form2.dataChanged += delegate(parameters) { 
        BeginInvoke(new Action(delegate { 
            BeginInvoke(new DataChangeListener(myListener), parameters);
        }));
        //Or,
        BeginInvoke(new Func<Delegate, object[], IAsyncResult>(BeginInvoke),
                    new object[] { parameters }
        );
    };
