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
    
            const char firstLetter = 'a';
    
            // Only for you I also added black and white fields
            var isBlackField = false;
            var black = new Color(0, 0, 0, 0.25f);
            var white = new Color(1, 1, 1, 0.25f);
    
            //makes the 8 by 8
    
            //rows
            for (var i = 0; i <= 8; i++)
            {
                var start = Vector3.forward * i;
                Debug.DrawLine(start, start + widthLine);
    
                //colums
                for (var j = 0; j <= 8; j++)
                {
                    var currentLatter = (char)(firstLetter + j);
                    start = Vector3.right * j;
                    Debug.DrawLine(start, start + heightLine);
    
                    // this flag alternates between black and white
                    isBlackField = !isBlackField;
    
                    // Since you draw the last line but don't want a field added skip if over 8
                    if (i >= 8 || j >= 8) continue;
    
                    var centerOfField = Vector3.forward * (i + 0.5f) + Vector3.right * (j + 0.5f);
    
                    // Draw text label on fields with colum char + row index
                    Handles.Label(centerOfField, currentLatter.ToString() + (i + 1));
    
                    Gizmos.color = isBlackField ? black : white;
                    Gizmos.DrawCube(Vector3.forward * (i + 0.5f) + Vector3.right * (j + 0.5f), new Vector3(1, 0.01f, 1));
                }
            }
        }
    }
