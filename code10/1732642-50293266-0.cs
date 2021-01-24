    Public GameObject bulletPrefab;
    Public GameObject pointOnGunBulletShootsFrom;
    private float halfAngleofCone
    
    private void FireBulletInsideCone()
    {
       GameObject bullet = Instantiate(bulletPrefab, pointOnGunBulletShootsFrom.transform.position, pointOnGunBulletShootsFrom.transform.rotation);
       float angleToAdjustBy = Random.Range(0,halfAngleofCone);
       bullet.transform.Rotate(Vector3.up * angleToAdjustBy );
       bullet.rigidbody.AddForce(transform.forward * 100f);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           FireBulletInsideCone();
        }
    }
