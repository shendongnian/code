    public class MyModel
    {
        [RegularExpression("^(?!0*(\.0+)?$)(\d+|\d*\.\d+)$", ErrorMessage = "Not Equal to Zero")]
        public double WhateverButNotZero { get; set; }
    }
