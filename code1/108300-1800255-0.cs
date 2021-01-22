            int value;
            if(DoSomethingWonderful(out value))
            {
                // continue on your merry way
            }
            else
            {
                // oops
                Log("Unable to do something wonderful");
                if (DoSomethingTerrible(out value))
                {
                    // continue on your not-so-merry way
                }
                else
                {
                    GiveUp();
                }
            }
