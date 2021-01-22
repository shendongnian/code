    interface Interface1<T> where T : HtmlControl
    { // May use T for future methods which will be generic in nature eg work with a generic collection of instances of T (not depicted in the method signature below)
        void DoStuff();
    }
    class Child1 : Interface1<ArtOfTest.WebAii.Controls.HtmlControls.HtmlAnchor>
    {
        public void DoStuff()
        {
            throw new NotImplementedException();
        }
    }
    class Test
    {
        
        public Interface1<HtmlControl> ReturnExperiment()
        {
            Child1 child1 = new Child1();
            return child1;
        }
    }
