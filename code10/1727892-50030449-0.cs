    static public void EnhancedInsertionSort(ArrayList List)
    {
        int n = List.Count;
        int i = 1;
        int j = i-1;
    
        do
        {
            if ( pageWithLessVisits(List[i], List[i - 1]) )
            {
                if ( pageWithLessVisits(List[i], List[0]) )
                {
                    j = 0;
                    object temp = List[i];
                    List[i] = List[j];
                    List[j] = temp;
                    j++;
                }
                else
                    j = i / 2;
            }
            else
                i++;
            if (pageWithLessVisits(List[i],List[j]))
            {
                while ((j - 1) >= 0)
                {
                    j = j - 2;
                    if (pageWithMoreVisits(List[i], List[j]))
                    {
                        if (pageWithLessVisits(List[i],List[j + 1]))
                        {
                            j = j + 1;
                            object temp = List[i];
                            List[i] = List[j];
                            List[j] = temp;
                            j++;
                        }
                    }
                    else
                    {
                        if (pageWithEqualVisits(List[i], List[j]))
                            j = j + 1;
                        else return;
                    }
                }
            }
            else
                if (pageWithEqualVisits(List[i], List[j]))
                    j = j + 1;
    
        } while (j == i-1);
    
    }
    
    static private bool pageWithLessVisits(Webpage page1, Webpage page2)
    {
        return page1.getVisits() < page2.getVisits()
    }
    static private bool pageWithMoreVisits(Webpage page1, Webpage page2)
    {
        return page1.getVisits() > page2.getVisits()
    }
    static private bool pageWithEqualVisits(Webpage page1, Webpage page2)
    {
        return page1.getVisits() == page2.getVisits()
    }
