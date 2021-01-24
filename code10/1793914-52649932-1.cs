       using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class NewBehaviourScript : MonoBehaviour {
    
    
    public int width = 256;
    public int height = 140;
    public int borderThickness = 1;  //Cannot be < 1
    //Border shadow cannot be more than Border Radius
    public int borderRadius = 40; //Cannot be < 1
    public int borderShadow = 2;
    public List<Color32> backgroundColors = new List<Color32>();
    public List<Color32> borderColors = new List<Color32>();
    public float initialShadowIntensity = 5f;
    public float finalShadowIntensity = 5f;
    
    public float resolutionmultiplier = 4f;
    
    
    private Texture2D resultTex;
    public RawImage display;
    
    public RectTransform rt;
    
    void Start()
    {
        backgroundColors.Add(new Color32(171, 0, 0, 255));
        backgroundColors.Add(new Color32(9, 48, 173, 255));
    
        borderColors.Add(new Color32(111, 8, 99, 255));
        borderColors.Add(new Color32(171, 4, 161, 255));
    
        resultTex = RectangleCreator.
            CreateRoundedRectangleTexture(4, width, height, borderThickness,
            borderRadius, borderShadow, backgroundColors, borderColors,
            initialShadowIntensity, finalShadowIntensity);
    
        display.texture = resultTex;
        rt.sizeDelta = new Vector2(width, height);
    }
    
    
    
    public class RectangleCreator
    {
        public static Texture2D CreateRoundedRectangleTexture(int resolutionmultiplier, int width, int height, int borderThickness, int borderRadius, int borderShadow, List<Color32> backgroundColors, List<Color32> borderColors, float initialShadowIntensity, float finalShadowIntensity)
        {
           // if (backgroundColors == null || backgroundColors.Count == 0) throw new ArgumentException("Must define at least one background color (up to four).");
          //  if (borderColors == null || borderColors.Count == 0) throw new ArgumentException("Must define at least one border color (up to three).");
          //  if (borderRadius < 1) throw new ArgumentException("Must define a border radius (rounds off edges).");
          //  if (borderThickness < 1) throw new ArgumentException("Must define border thikness.");
         //   if (borderThickness + borderRadius > height / 2 || borderThickness + borderRadius > width / 2) throw new ArgumentException("Border will be too thick and/or rounded to fit on the texture.");
         //   if (borderShadow > borderRadius) throw new ArgumentException("Border shadow must be lesser in magnitude than the border radius (suggeted: shadow <= 0.25 * radius).");
    
            width = width * resolutionmultiplier;
            height = height * resolutionmultiplier;
    
            Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
            Color32[] color = new Color32[width * height];
    
            for (int x = 0; x < texture.width; x++)
            {
                for (int y = 0; y < texture.height; y++)
                {
                    switch (backgroundColors.Count)
                    {
                        case 4:
                            Color32 leftColor0 = Color32.Lerp(backgroundColors[0], backgroundColors[1], ((float)y / (width - 1)));
                            Color32 rightColor0 = Color32.Lerp(backgroundColors[2], backgroundColors[3], ((float)y / (height - 1)));
                            color[x + width * y] = Color32.Lerp(leftColor0, rightColor0, ((float)x / (width - 1)));
                            break;
                        case 3:
                            Color32 leftColor1 = Color32.Lerp(backgroundColors[0], backgroundColors[1], ((float)y / (width - 1)));
                            Color32 rightColor1 = Color32.Lerp(backgroundColors[1], backgroundColors[2], ((float)y / (height - 1)));
                            color[x + width * y] = Color32.Lerp(leftColor1, rightColor1, ((float)x / (width - 1)));
                            break;
                        case 2:
                            color[x + width * y] = Color32.Lerp(backgroundColors[0], backgroundColors[1], ((float)x / (width - 1)));
                            break;
                        default:
                            color[x + width * y] = backgroundColors[0];
                            break;
                    }
    
                    color[x + width * y] = ColorBorder(x, y, width, height, borderThickness, borderRadius, borderShadow, color[x + width * y], borderColors, initialShadowIntensity, finalShadowIntensity);
                }
            }
    
            texture.SetPixels32(color);
            texture.Apply();
            return texture;
        }
    
        private static Color32 ColorBorder(int x, int y, int width, int height, int borderThickness, int borderRadius, int borderShadow, Color32 initialColor, List<Color32> borderColors, float initialShadowIntensity, float finalShadowIntensity)
        {
            Rect internalRectangle = new Rect((borderThickness + borderRadius), (borderThickness + borderRadius), width - 2 * (borderThickness + borderRadius), height - 2 * (borderThickness + borderRadius));
    
    
            Vector2 point = new Vector2(x, y);
            if (internalRectangle.Contains(point)) return initialColor;
    
            Vector2 origin = Vector2.zero;
    
            if (x < borderThickness + borderRadius)
            {
                if (y < borderRadius + borderThickness)
                    origin = new Vector2(borderRadius + borderThickness, borderRadius + borderThickness);
                else if (y > height - (borderRadius + borderThickness))
                    origin = new Vector2(borderRadius + borderThickness, height - (borderRadius + borderThickness));
                else
                    origin = new Vector2(borderRadius + borderThickness, y);
            }
            else if (x > width - (borderRadius + borderThickness))
            {
                if (y < borderRadius + borderThickness)
                    origin = new Vector2(width - (borderRadius + borderThickness), borderRadius + borderThickness);
                else if (y > height - (borderRadius + borderThickness))
                    origin = new Vector2(width - (borderRadius + borderThickness), height - (borderRadius + borderThickness));
                else
                    origin = new Vector2(width - (borderRadius + borderThickness), y);
            }
            else
            {
                if (y < borderRadius + borderThickness)
                    origin = new Vector2(x, borderRadius + borderThickness);
                else if (y > height - (borderRadius + borderThickness))
                    origin = new Vector2(x, height - (borderRadius + borderThickness));
            }
    
            if (!origin.Equals(Vector2.zero))
            {
                float distance = Vector2.Distance(point, origin);
    
                if (distance > borderRadius + borderThickness + 1)
                {
                    return Color.clear;
                }
                else if (distance > borderRadius + 1)
                {
                    if (borderColors.Count > 2)
                    {
                        float modNum = distance - borderRadius;
    
                        if (modNum < borderThickness / 2)
                        {
                            return Color32.Lerp(borderColors[2], borderColors[1], (float)((modNum) / (borderThickness / 2.0)));
                        }
                        else
                        {
                            return Color32.Lerp(borderColors[1], borderColors[0], (float)((modNum - (borderThickness / 2.0)) / (borderThickness / 2.0)));
                        }
                    }
    
    
                    if (borderColors.Count > 0)
                        return borderColors[0];
                }
                else if (distance > borderRadius - borderShadow + 1)
                {
                    float mod = (distance - (borderRadius - borderShadow)) / borderShadow;
                    float shadowDiff = initialShadowIntensity - finalShadowIntensity;
                    return DarkenColor(initialColor, ((shadowDiff * mod) + finalShadowIntensity));
                }
            }
    
            return initialColor;
        }
    
        private static Color32 DarkenColor(Color32 color, float shadowIntensity)
        {
            return Color32.Lerp(color, Color.black, shadowIntensity);
        }
    }
    }
