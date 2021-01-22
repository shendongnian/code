        object Controled = null; // Default is that we don't know what this is
        if (ObjectToControl is DataList)
            Controled = ObjectToControl as DataList;
        else if (ObjectToControl is DetailsView)
            Controled = ObjectToControl as DetailsView;
        else if (ObjectToControl is FormView)
            Controled = ObjectToControl as FormView;
        else if (ObjectToControl is ListView)
            Controled = ObjectToControl as ListView;
        else if (ObjectToControl is GridView)
            Controled = ObjectToControl as GridView;
