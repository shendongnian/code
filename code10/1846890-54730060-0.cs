    using UnityEngine;
    public class Grass_Follow : MonoBehaviour
    {        
        Terraform terraformScript; 
        void Awake()
        {
            GameObject TerraformButt = GameObject.Find("Terraform");
            terraformScript = TerraformButt.GetComponent<Terraform>();
        }
        void Update()
        {
            if (terraformScript.TerraformClick == 1)
            {
                Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = pz;
            }
        }
    }
