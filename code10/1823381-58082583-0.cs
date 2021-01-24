void Update()
{
     if (Input.GetButtonDown("Fire1"))
    {
        GetComponent<Animator>().SetTrigger("Fire");
        Shoot();
    }
}
