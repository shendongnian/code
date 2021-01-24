    using UnityEditor;
    using UnityEngine;
    
    public class ChessFieldDebug : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            //8 units of 1 meter to the right
            var widthLine = Vector3.right * 8;
            //8 units of 1 meter up
            var heightLine = Vector3.forward * 8;
    
            var letter = 'a';
    
            bool isBlackField = false;
    
            //makes the 8 by 8
    
            //rows
            for (var i = 0; i <= 8; i++)
            {
                var start = Vector3.forward * i;
                Debug.DrawLine(start, start + widthLine);
    
                //colums
                for (var j = 0; j <= 8; j++)
                {
                    start = Vector3.right * j;
                    Debug.DrawLine(start, start + heightLine);
    
                    // Only for you I also added black and white fields
                    // this flag alternates between black and white
                    isBlackField = !isBlackField;
    
                    if (i < 8 && j < 8)
                    {
                        // Draw text label with colum char + row index
                        Handles.Label(Vector3.forward * (i + 0.5f) + Vector3.right * (j + 0.5f), letter.ToString() + (i + 1));
    
                        
    
                        Gizmos.color = isBlackField ? new Color(0, 0, 0, 0.25f) : new Color(1, 1, 1, 0.25f);
    
                        Gizmos.DrawCube(Vector3.forward * (i + 0.5f) + Vector3.right * (j + 0.5f), new Vector3(1, 0.01f, 1));
                    }
    
                    if (j >= 8) continue;
                    // count alphabetic char up
    
                    letter = (char)(letter + 1);
                    if (letter == 'i')
                    {
                        letter = 'a';
                    }
                }
            }
        }
    }
