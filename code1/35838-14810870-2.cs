    public void Test(out settable string name, gettable int count, bool whatever)
    {
        name = "someone else";
    }
    Test(out p.Name, 0, true); // doesnt compile since p.Name is readonly.
