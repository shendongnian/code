    void Start () {
       ParticleSystem ps = gameObject.GetComponent<ParticleSystem>();
       ParticleSystem.MainModule psMain = ps.main;
       psMain.startColor.colorMax = Color.red;
       psMain.startColor.colorMin = Color.white;
    }
