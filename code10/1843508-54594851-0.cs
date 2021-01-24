    // Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
    // Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
    
    Shader "Custom/MetallicHighlights" {
        Properties {
            _Color ("Color", Color) = (1, 1, 1, 1)
            _MainTex ("Albedo", 2D) = "white" {}
    
            _GlossMapScale ("Smoothness", Range(0.0, 1.0)) = 0.0
            _MetallicFactor("Metallic Factor", Range(0.0, 1.0)) = 0
            _MetallicGlossMap ("Metallic", 2D) = "gloss" {}
            [ToggleOff] _SpecularHighlights("Specular Highlights", Float) = 1.0
        }
        SubShader {
            Tags { "RenderType"="Opaque" }
            LOD 200
    
            CGPROGRAM
            // Physically based Standard lighting model, and enable shadows on all light types
            // And generate the shadow pass with instancing support
            #pragma surface surf Standard fullforwardshadows addshadow
            #pragma shader_feature _SPECULARHIGHLIGHTS_OFF
    
            // Use shader model 3.0 target, to get nicer looking lighting
            #pragma target 3.0
    
            struct Input {
                float4 color: Color;
                float2 uv_MainTex;
                float3 viewDir;
            };
    
            sampler2D _MainTex;
            sampler2D _MetallicGlossMap;
            fixed4 _Color;
            half _GlossMapScale;
            half _MetallicFactor;
    
            void surf (Input IN, inout SurfaceOutputStandard o) {
                // Albedo comes from a texture tinted by color
                fixed4 albedo = tex2D (_MainTex, IN.uv_MainTex) * _Color;
                o.Albedo = albedo.rgb;
                o.Alpha = albedo.a;
    
                half rim = _RimCap - saturate(dot(normalize(IN.viewDir), o.Normal));
                o.Emission = _RimColor.rgb * pow(rim, _RimIntensity);
    
                // Metallic and smoothness come from slider variables
                // o.Metallic = _MetallicFactor;
                // o.Smoothness = _GlossMapScale;
    
                fixed4 metal_colour = tex2D(_MetallicGlossMap, IN.uv_MainTex);
                o.Metallic = metal_colour.r * _MetallicFactor;
                o.Smoothness = metal_colour.a * _GlossMapScale;
            }
            ENDCG
        }
        FallBack "Diffuse"
    }
