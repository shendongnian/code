    private void OnTriggerExit2D(Collider2D col)
    {
        for (var i = 0; i < 9; i++)
        {
            if (col.name == "monster" + i)
            {
                monster[i] = false;
            }
        }
    }
