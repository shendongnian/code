    // C#
    class OuterClass 
    {
        string s;
        // ...
        class InnerClass 
        {
           OuterClass o_;
           public InnerClass(OuterClass o) { o_ = o; }
           public string GetOuterString() { return o_.s; }
        }
        void SomeFunction() {
            InnerClass i = new InnerClass(this);
            i.GetOuterString();
        }
    }
