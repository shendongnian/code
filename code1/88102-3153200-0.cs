            ...
            vec3 pos = new vec3(10f,0f,0f);
            gl.Disable(EnableCap.Lighting);
            gl.LineWidth(2f);
            gl.Color3(col.DimGray);
            gl.Begin(BeginMode.Lines);
            gl.Vertex3(0.0, 0.0, 0.0);
            gl.Vertex3(pos);
            gl.End();
            gl.Enable(EnableCap.Lighting);
            ...
