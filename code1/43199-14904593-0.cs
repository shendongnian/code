    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace BAL
    {
    class ProductItem
    {
        // Global Variable to store the value of which radio button should be checked
        private int glbTaxStatus;
        // Public variable to set initial value passed from 
        // database query and get value to save to database
        public int TaxStatus
        {
            get { return glbTaxStatus; }
            set { glbTaxStatus = value; }
        }
        // Get/Set for 1st Radio button
        public bool Resale
        {
            // If the Global Variable = 1 return true, else return false
            get
            {
                if (glbTaxStatus.Equals(1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // If the value being passed in = 1 set the Global Variable = 1, else do nothing
            set
            {
                if (value.Equals(true))
                {
                    glbTaxStatus = 1;
                }
            }
        }
        // Get/Set for 2nd Radio button
        public bool NeverTax
        {
            // If the Global Variable = 2 return true, else return false
            get
            {
                if (glbTaxStatus.Equals(2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // If the value being passed in = 2 set the Global Variable = 2, else do nothing
            set
            {
                if (value.Equals(true))
                {
                    glbTaxStatus = 2;
                }
            }
        }
        // Get/Set for 3rd Radio button
        public bool AlwaysTax
        {
            // If the Global Variable = 3 return true, else return false
            get
            {
                if (glbTaxStatus.Equals(3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // If the value being passed in = 3 set the Global Variable = 3, else do nothing
            set
            {
                if (value.Equals(true))
                {
                    glbTaxStatus = 3;
                }
            }
        }
    // More code ...
