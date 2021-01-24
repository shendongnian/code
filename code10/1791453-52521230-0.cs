     using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using System;
        
        public class MapGenerator : MonoBehaviour {
            public int width;
            public int height;
        
            public string seed;
            public bool useRandomSeed;
        
            [Range(0,100)]
            public int randomFillPercent;
            int[,] map;
        
            private void Start()
            {
                GenerateMap();
            }
        
            void GenerateMap()
            {
                map = new int[width, height];
                RandomFillMap();
        
                for (int i = 0; i < 5; i++)
                {
                    SmoothMap();
                }
            }
            void RandomFillMap()
            {
                if (useRandomSeed)
                {
                    seed = Time.time.ToString();
                }
                System.Random prng = new System.Random(seed.GetHashCode());
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                        {
                            map[x, y] = 1;
                        }
                        else
                        {
                            map[x, y] = (prng.Next(0, 100) < randomFillPercent) ? 1 : 0;
                        }
                    }
        
                }
            }
            private void Update()
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GenerateMap();
                }
            }
            void SmoothMap()
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        int neighborWallTiles = GetSurroundingWallCount(x, y);
                        if (neighborWallTiles > 4)
                        {
                            map[x, y] = 1;
                        }
                        else if (neighborWallTiles<4)
                        {
                            map[x, y] = 0;
                        }
        
                    }
                }
                    }
        
            int GetSurroundingWallCount(int gridx, int gridy)
            {
                int wallcount = 0;
                for(int neighborx=gridx-1; neighborx<=gridx + 1; neighborx++)
                {
                    for (int neighbory = gridy - 1; neighbory <= gridy + 1; neighbory++)
                    {
                        if (neighborx >= 0 && neighborx < width && neighbory >= 0 && neighbory < height)
                        {
                            
                            if (neighborx != gridx || neighbory != gridy)
                            {
                                wallcount += map[neighborx, neighbory];
                            }
                        }
                        else
                        {
                            wallcount++;
                        }
                     
                    }
                }
                return wallcount;
            }
        
                void OnDrawGizmos()
                {
                    if (map != null)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            for (int y = 0; y < height; y++)
                            {
                            Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
                            Vector3 pos = new Vector3(-width / 2 + x + .5f, 0, -height / 2 + y + .5f);
                            Gizmos.DrawCube(pos, Vector3.one);
                            }
                        }
                    }
                
            }
        
        }
