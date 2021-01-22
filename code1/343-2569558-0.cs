            //Sorts sections according to the key value stored on "sections" unsorted dictionary, which is passed as a constructor argument
            System.Collections.Generic.SortedDictionary<int, string> sortedSections = null;
            if (sections != null)
            {
                System.Collections.Generic.sortedSections = new SortedDictionary<int, string>(sections);
            }
