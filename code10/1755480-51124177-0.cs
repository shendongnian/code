    oid Shooting()
    {
        if (Input.GetButton(DualShock4.Input(InputCode.L2)))
        {
            if (Input.GetButtonDown(DualShock4.Input(InputCode.R2)))
            {
                if (weapons[1].ammoAmount > weapons[1].shotBullets) weapons[1].shotBullets += 1;
                else if (weapons[2].ammoAmount > weapons[2].shotBullets) weapons[2].shotBullets += 1;
            }
        }
    }
    void Bullets(Image[] bullets, int index)
    {
        int liveAmmo = weapons[index].ammoAmount - shotBullets; 
        for (int i = 0; i < weapons[index].ammoAmount; i++)
        {
            bullets[i].gameObject.SetActive((i<liveAmmo));
        }
    }
