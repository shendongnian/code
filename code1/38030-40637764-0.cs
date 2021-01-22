    //Two way binding between neasted properties:
    Bind.TwoWay(()=> client.Area.Data.Name == this.AreaName);
    //On change action execute:
    Bind
        .OnChange(()=> client.Personal.Name)
        .Do(x => clientName = x);
