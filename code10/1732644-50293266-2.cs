    Public GameObject bulletPrefab;
    Public GameObject pointOnGunBulletShootsFrom; // In your image this would be the emitter
    private float halfAngleofCone = 30f; // In your image this would be the distance between C and L.
    private float bulletSpeedModifier = 100f; // If you have another way of propelling your bullets you can remove this and the addforce section.
    
    private void FireBulletInsideCone()
    {
       GameObject bullet = Instantiate(bulletPrefab, pointOnGunBulletShootsFrom.transform.position, pointOnGunBulletShootsFrom.transform.rotation);
       float angleToAdjustBy = Random.Range(0,halfAngleofCone);
       bullet.transform.Rotate(Vector3.up * angleToAdjustBy );
       bullet.rigidbody.AddForce(transform.forward * bulletSpeedModifier);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           FireBulletInsideCone();
        }
    }
