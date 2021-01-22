    #define ATTEMPT(x) try { x; } catch (...) { }
    // ...
    ATTEMPT(WidgetMaker.SetAlignment(57));
    ATTEMPT(contactForm["Title"] = txtTitle.Text);
    ATTEMPT(Casserole.Season(true, false));
    ATTEMPT(((RecordKeeper)Session["CasseroleTracker"]).Seasoned = true);
