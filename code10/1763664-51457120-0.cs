    public class MyModel
    {
        [RegularExpression("[^0]+", ErrorMessage = "Not Equal to Zero")]
        public double WhateverButNotZero { get; set; }
    }
