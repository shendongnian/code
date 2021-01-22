    class X
    {
        void T()
        {
            NTree<int> nti = new NTree<int>(2);
            nti.Traverse(nti, delegate(int i) { return i > 4; });
        }
    }
