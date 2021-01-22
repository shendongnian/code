    class BaseClassWithSharedProperties
    {
        public Int32 SharedId { get; set; }
        public String SharedName { get; get; }
    }
    class UniqueClassNumberOne : BaseClassWithSharedProperties
    {
        public UniqueClassNumberOneProperty { get; set; }
    }
    class UniqueClassNumberTwo : BaseClassWithSharedProperties
    {
        public UniqueClassNumberTwoProperty { get; set; }
    }
