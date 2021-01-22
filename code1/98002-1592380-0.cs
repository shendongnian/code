            for (var i = 0; i < positions.Count; i++)
            {
                Point3D position = positions[i];
                position.Z += 5;
                positions[i] = position;
            }
