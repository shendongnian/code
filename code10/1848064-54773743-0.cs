    using UnityEngine;
    
    public class World : MonoBehaviour
    {
        public GameObject cube;
        public int volume;
    
        private void Awake()
        {
            int i = 0;
            for (int x = 0; x < volume; x++)
            {
                for (int y = 0; y < volume; y++)
                {
                    for (int z = 0; z < volume; z++)
                    {
                        // ignores the cubes that are not placed on the limits
                        if (x != 0 && x != volume - 1 
                            && y != 0 && y != volume - 1 
                            && z != 0 && z != volume - 1) continue;
    
                        i++;
    
                        var go = Instantiate(cube);
                        go.name = "Cube " + i;
                        go.transform.position = new Vector3
                        {
                            x = x,
                            y = y,
                            z = z
                        };
                    }
                }
            }
        }
    }
