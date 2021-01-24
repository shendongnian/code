    void OnTriggerStay(Collider other)
    {
        GameObject gui = GameObject.FindWithTag("GUIJar");
        if (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.Tab))
        {
            if (other.gameObject.tag == "GunPickup")
            {
                if (gui.GetComponent<GUIJar>().WaitForWeaponSwitch == false)
                {
                    gui.GetComponent<GUIJar>().SetWeaponSwitch();
                    // Object.Destroy(other.gameObject);
                    DropWeapons();
                    SpawnReplacementPlayer("Player(gun)", other.gameObject);
                }
                return;
            }
            if (other.gameObject.tag == "ShotgunPickup")
            {
                if (gui.GetComponent<GUIJar>().WaitForWeaponSwitch == false)
                {
                    gui.GetComponent<GUIJar>().SetWeaponSwitch();
                    //Object.Destroy(other.gameObject);
                    DropWeapons();
                    SpawnReplacementPlayer("Player(shotgun)", other.gameObject);
                }
                return;
            }
            if (other.gameObject.tag == "GrenadeLauncherPickup")
            {
                if (gui.GetComponent<GUIJar>().WaitForWeaponSwitch == false)
                {
                    gui.GetComponent<GUIJar>().SetWeaponSwitch();
                    //Object.Destroy(other.gameObject);
                    DropWeapons();
                    SpawnReplacementPlayer("Player(grenade)", other.gameObject);
                }
                return;
            }
            if (other.gameObject.tag == "BatPickup")
            {
                if (gui.GetComponent<GUIJar>().WaitForWeaponSwitch == false)
                {
                    gui.GetComponent<GUIJar>().SetWeaponSwitch();
                    //Object.Destroy(other.gameObject);
                    DropWeapons();
                    SpawnReplacementPlayer("Player", other.gameObject);
                }
                return;
            }
            if (other.gameObject.tag == "KnifePickup")
            {
                if (gui.GetComponent<GUIJar>().WaitForWeaponSwitch == false)
                {
                    gui.GetComponent<GUIJar>().SetWeaponSwitch();
                    //Object.Destroy(other.gameObject);
                    DropWeapons();
                    SpawnReplacementPlayer("Player(knife)", other.gameObject);
                }
                return;
            }
        }
    }
