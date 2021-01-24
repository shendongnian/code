    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Runner":
                {
                    Runner runner = collision.GetComponent<Runner>();
                    if (runner)
                    {
                        runner.Destroy();
                    }
                    break;
             case "Jumper":
                {
                    Jumper jumper = collision.GetComponent<Jumper>();
                    if (jumper)
                    {
                        jumper.Destroy();
                    }
                    break;
                }
        }
    }
