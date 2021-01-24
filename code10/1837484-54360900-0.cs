    Game g = new Game();
    g.Color = Color.Black;
    Scene scn = new Scene();
    Text t = new Text("Text","Font",16);
    Entity ent = new Entity();
    ent.AddGraphics(t);
    scn.Add(ent);
    g.Start(scn);
