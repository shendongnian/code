    public class MyModel
    {
        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)")]
        public double WhateverButNotZero { get; set; }
    }
