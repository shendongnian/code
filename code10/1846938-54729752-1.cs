    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Runner":
                {
                    Enemy enemy = collision.GetComponent<Runner>();
                    if (enemy)
                    {
                        enemy.Destroy();
                    }
                    break;
             case "Jumper":
                {
                    Enemy enemy = collision.GetComponent<Jumper>();
                    if (enemy)
                    {
                        enemy.Destroy();
                    }
                    break;
                }
        }
    }
