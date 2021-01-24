    class MyPagerAdapter : PagerAdapter
    {
        List<View> viewlist;
        public MyPagerAdapter(List<View> viewlist)
        {
            this.viewlist = viewlist;
        }
        public override int Count => 2;
        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return view == @object;
        }
        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            container.AddView(viewlist[position]);
            return viewlist[position];
        }
        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
        {
            container.RemoveView(viewlist[position]);
        }
    }
