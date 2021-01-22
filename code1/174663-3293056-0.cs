    private int getTotalChildren(int id) 
    {
        int total=0;
        for (int i = 0; i < persons.Count;i++ )
        {
            if (persons[i].Manager == id)
            {
                total += 1;
                if(persons[i].Manager != persons[i].Id)
                {
                    total += getTotalChildren(persons[i].Id);
                }
            }
        }
        return total;
    }
