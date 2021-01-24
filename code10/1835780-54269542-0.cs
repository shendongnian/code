void OnTriggerEnter(Collider other)
{
    if (Health > 3)
    {
        Health--;
        Debug.Log(Health);
    }
    else
    {
        GameOver();
    }
}
