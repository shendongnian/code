    static public void main(string[] args)
    {
        //initialize the aspect
        var myaspect = new MyAspect();
        //Weave the aspect to Calculator class.
        myaspect.Manage<Calculator>();
    }
