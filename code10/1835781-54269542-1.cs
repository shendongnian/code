void OnTriggerEnter(Collider other)
{
    if (Health > 0)
    {
        Health--;
        Debug.Log(Health);
    }
    else
    {
        GameOver();
    }
}
